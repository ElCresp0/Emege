FROM node:25

WORKDIR /app

# copy package info to install
COPY package*.json ./

RUN npm install

# copy remaining files after packages installation so that it's cached
COPY . .

EXPOSE 3000

CMD ["npm", "run", "dev", "--", "--host"]
# CMD ["npm", "run", "build"]