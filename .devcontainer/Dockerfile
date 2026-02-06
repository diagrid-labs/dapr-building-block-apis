FROM mcr.microsoft.com/devcontainers/dotnet:1-9.0-bookworm

# Remove the Yarn repository that has an expired/invalid GPG key
# This prevents apt-get update failures during feature installation
RUN rm -f /etc/apt/sources.list.d/yarn.list || true
