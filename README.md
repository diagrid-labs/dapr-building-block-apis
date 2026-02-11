# Dapr Building Block APIs

This repo contains Dapr applications to demonstrate several Dapr building block APIs and the built-in resiliency capabilities.

> Running the DemoTime demos in this repo is recommended since this gives more context about:
>
> - The Dapr OSS project
> - State Management API
> - Service Invocation API
> - Pub/Sub API
> - Resiliency policies
> - Dapr Workflow

## Table of Contents

- [Prequisites](#prerequisites)
- [Running the demos with DemoTime](#running-the-demos-with-demotime)
- [Diagrid Dev Dashboard](#diagrid-dev-dashboard)
- [Diagrid Catalyst](#diagrid-catalyst)
- [Resources](#resources)

## Prerequisites

Ensure you have these installed on your machine:

- [.NET 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Dapr CLI](https://docs.dapr.io/getting-started/install-dapr-cli/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [VSCode](https://code.visualstudio.com/) - Although other IDEs can be used to view the code, some VSCode specific extensions are used (such as [DemoTime](https://marketplace.visualstudio.com/items?itemName=eliostruyf.vscode-demo-time)) to help guide you through the slides and the codebase.
- For *Demo 1b* and *Demo 2* a Postgres database is required that can be installed via docker:

    ```bash
    docker pull postgres:latest
    docker run --name postgres -e POSTGRES_PASSWORD=postgres123 -d postgres -p 5432:5432 
    ```

1. Clone the this repo to your local machine.
2. Open the cloned repo in VSCode and accept the suggested VSCode extensions.

## Running the demos with DemoTime

Click the play button in the DEMO TIME panel in the explorer to start the slides and demos.

Progress through the slides and demos by clicking the DEMO TIME icon in the status bar or the next step in the DEMO TIME panel in the explorer.

**Demo 1a, 1b, 2**
![State Management](/.demo/slides/images/dapr-kv-2.png)

**Demo 3**
![Service Invocation](/.demo/slides/images/dapr-s2s-3.png)

**Demo 4**
![Pub/Sub](/.demo/slides/images/dapr-pubsub-3.png)

**Demo 5**
![Workflow](/.demo/slides/images/dapr-workflow-engine.png)

### Diagrid Dev Dashboard

The [Diagrid Dev Dashboard](https://www.diagrid.io/blog/improving-the-local-dapr-workflow-experience-diagrid-dashboard) is used during local development of Dapr workflow applications. It shows the workflow state, and the full execution history of the workflow instances.

![Diagrid Dev Dashboard](/.demo/slides/images/diagrid-dev-dashboard-1.jpeg)

![Diagrid Dev Dashboard](/.demo/slides/images/diagrid-dev-dashboard-2.jpeg)

### Diagrid Catalyst

If you're running Dapr Workflow applications in production check out [Diagrid Catalyst](https://www.diagrid.io/catalyst), the enterprise platform for Dapr Workflow and Agentic AI.

![Diagrid Catalyst](/.demo/slides/images/diagrid-catalyst.png)

## Resources

- [Learn Dapr with Dapr University](https://diagrid.io/dapr-university/)
- [Dapr Docs: Service Invocation](https://docs.dapr.io/developing-applications/building-blocks/service-invocation/)
- [Dapr Docs: State Management](https://docs.dapr.io/developing-applications/building-blocks/state-management/)
- [Dapr Docs: Pub/Sub](https://docs.dapr.io/developing-applications/building-blocks/pubsub/)
- [Dapr Docs: Resiliency](https://docs.dapr.io/operations/resiliency/)
- [Dapr Docs: Workflow](https://docs.dapr.io/developing-applications/building-blocks/workflow/workflow-overview/)
