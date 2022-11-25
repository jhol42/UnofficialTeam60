az login
$TOKEN=$(az acr login --name team60.azurecr.io --expose-token --output tsv --query accessToken)
docker login team60.azurecr.io --username 00000000-0000-0000-0000-000000000000 --password $TOKEN
docker tag team60.azurecr.io/kingmanazfrcteam60:dev team60.azurecr.io/kingmanazfrcteam60:latest
docker push 
