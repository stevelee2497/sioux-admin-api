CURRENT_PATH=$(pwd)
OUTPUT_PATH="${CURRENT_PATH}/build-api"

echo "Cleaning ..."
rm -rf build-api
mkdir -p build-api

echo "Building API packages ..."
cd API
dotnet publish API.csproj -o "${OUTPUT_PATH}"

cd "${CURRENT_PATH}"