CURRENT_PATH=$(pwd)
BUILD_FOLDER=build-api
OUTPUT_PATH="${CURRENT_PATH}/build-api"
REMOTE_ID=ubuntu@52.187.169.33
DEPLOYMENT_REMOTE_PATH='~/sioux-admin-api'
CONTAINER=sioux-admin-api

echo "Cleaning ..."
rm -rf ${BUILD_FOLDER}
mkdir -p ${BUILD_FOLDER}

echo "Building API packages ..."
cd API
dotnet publish API.csproj -o "${OUTPUT_PATH}"

cd "${CURRENT_PATH}"

read -r -p "Sending build to server and restart service now? [y/N] " response
case "$response" in
    [yY][eE][sS]|[yY])
        echo "SENDING PACKAGE ..."
        scp -C -P 22 -r ${BUILD_FOLDER} ${REMOTE_ID}:${DEPLOYMENT_REMOTE_PATH}

        echo "RESTART DOCKER ..."
        export REMOTE_DOCKER_COMMAND="cd ${DEPLOYMENT_REMOTE_PATH};docker-compose up -d --force-recreate ${CONTAINER};"
        ssh -p 22 ${REMOTE_ID} ${REMOTE_DOCKER_COMMAND}
        ;;
    *)
        echo "not sending data, service not restarted. Exiting ..."
        ;;
esac