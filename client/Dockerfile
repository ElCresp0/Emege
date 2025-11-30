FROM node:25

WORKDIR /app

# set up vue app
# COPY package.json ./
COPY . .

RUN npm install

# COPY . .

EXPOSE 3000

CMD ["npm", "run", "dev", "--", "--host"]
# CMD ["npm", "run", "build"]