FROM python:3

WORKDIR /usr/src/app

COPY requirements.txt ./
RUN pip install torch torchvision
RUN pip install --no-cache-dir -r requirements.txt

COPY . .

CMD [ "python" ]