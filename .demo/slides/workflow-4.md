---
theme: default
layout: default
---

# ProfileWorkflow

```mermaid
flowchart TD
    Start([Start]) --> Validate[ValidationActivity]
    Validate --> Check{IsValid?}
    Check -->|No| Fail([Return Validatition Failure])
    Check -->|Yes| Store[StorageActivity]
    Store --> Notify[NotificationActivity]
    Notify --> End([End])

    style Start fill:#e1f5ff
    style Check fill:#fff3cd
    style End fill:#d4edda
    style Fail fill:#f8d7da
```
