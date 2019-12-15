CURRENT_PATH=$(pwd)
OUTPUT_PATH="${CURRENT_PATH}/build-api"

echo "Cleaning ..."
rm -rf build-api
mkdir -p build-api

echo "Building API packages ..."
cd API
dotnet publish API.csproj -o "${OUTPUT_PATH}"

cd "${CURRENT_PATH}"

echo "Send packages to server"
scp -C -r 'build-api' ssh ubuntu@52.187.169.33:~/sioux-admin-api
ssh ssh ubuntu@52.187.169.33 "cd ~/sioux-admin-api;docker-compose up -d --build sioux-admin-api"
