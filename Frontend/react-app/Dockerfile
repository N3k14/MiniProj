FROM node:20-alpine AS build
WORKDIR /app
COPY Frontend/react-app/package*.json .
RUN npm ci
COPY Frontend/react-app/ .
RUN npm run build

FROM node:20-alpine
RUN npm install -g serve
WORKDIR /app
COPY --from=build /app/build ./build

EXPOSE 3000

CMD ["serve", "-s", "build", "-l", "3000"]
