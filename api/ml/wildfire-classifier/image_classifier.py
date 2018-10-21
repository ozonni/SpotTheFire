from fastai.imports import *
from fastai.transforms import *
from fastai.conv_learner import *
from fastai.model import *
from fastai.dataset import *
from fastai.sgdr import *
from fastai.plots import *


class WildlifeClassifier:
    def __init__(self):
        self.arch = resnet34
        self.sz = 224
        self.path = 'mock-data/'
        data = ImageClassifierData.from_paths(self.path, tfms=tfms_from_model(self.arch, self.sz))
        self.learn = ConvLearner.pretrained(self.arch, data, precompute=True)
        self.learn.load('wildfire-model')

    def predict_single_image(self, image_path):
        _, val_tfms = tfms_from_model(self.arch, self.sz)  # get transformations
        im = val_tfms(open_image(image_path))
        self.learn.precompute = False  # We'll pass in a raw image, not activations
        preds = self.learn.predict_array(im[None])
        return np.exp(preds)[0, 1]  # preds are log probabilities of classes
