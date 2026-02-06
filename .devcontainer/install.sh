wget -q https://raw.githubusercontent.com/dapr/cli/master/install/install.sh -O - | /bin/bash
dapr uninstall
dapr init

# required for demo to send ctrl+c to terminal
sudo apt update
sudo apt -y install xdotool

#docker pull postgres:latest
#docker rm --force /postgres
#docker run --name postgres -e POSTGRES_PASSWORD=postgres123 -d -p 5432:5432 postgres