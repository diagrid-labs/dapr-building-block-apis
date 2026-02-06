# Plan: Create 6-workflow.json DemoTime File

This document describes how to create a `6-workflow.json` DemoTime file for demonstrating the Dapr Workflow building block.

## Overview

The DemoTime file will:
1. Display 2 markdown slides introducing the Workflow API
2. Start the Workflow application in the Demo5 folder using `dapr run -f .`

## Files to Create

### 1. Markdown Slides

Create two slide files in `/.demo/slides/`:

#### `workflow.md` (Title Slide)
```markdown
---
theme: default
layout: section
---

# Workflow API
```

#### `workflow-1.md` (Overview Slide)
```markdown
---
theme: default
layout: default
---

# Workflow API Overview

- **Durable Execution**: Automatically handles failures and retries
- **State Management**: Workflow state is persisted automatically
- **Activity Orchestration**: Chain multiple activities together
- **Long-running Processes**: Support for workflows that run for hours or days
```

### 2. DemoTime File

Create `/.demo/6-workflow.json` with the following structure:

```json
{
  "$schema": "https://demotime.elio.dev/demo-time.schema.json",
  "title": "6 - Workflow",
  "description": "This demo covers the Workflow building block.",
  "version": 2,
  "demos": [
    {
      "title": "Workflow",
      "description": "",
      "icons": {
        "start": "vm",
        "end": "pass-filled"
      },
      "steps": [
        {
          "action": "executeVSCodeCommand",
          "command": "workbench.action.terminal.killAll"
        },
        {
          "action": "executeVSCodeCommand",
          "command": "workbench.action.closeSidebar"
        },
        {
          "action": "openSlide",
          "path": "/.demo/slides/workflow.md"
        }
      ]
    },
    {
      "title": "Workflow Overview",
      "description": "",
      "icons": {
        "start": "vm",
        "end": "pass-filled"
      },
      "steps": [
        {
          "action": "openSlide",
          "path": "/.demo/slides/workflow-1.md"
        }
      ]
    },
    {
      "title": "Demo 5: WorkflowService Program.cs",
      "icons": {
        "start": "code",
        "end": "pass-filled"
      },
      "steps": [
        {
          "action": "highlight",
          "path": "/Demo5/WorkflowService/Program.cs",
          "position": 12
        },
        {
          "action": "executeTerminalCommand",
          "command": "cd Demo5",
          "terminalId": "dapr-run"
        },
        {
          "action": "executeTerminalCommand",
          "command": "dotnet build ./WorkflowService",
          "terminalId": "dapr-run"
        }
      ]
    },
    {
      "title": "Demo 5: ProfileWorkflow",
      "icons": {
        "start": "code",
        "end": "pass-filled"
      },
      "steps": [
        {
          "action": "highlight",
          "path": "/Demo5/WorkflowService/Workflows/ProfileWorkflow.cs",
          "position": 1
        }
      ]
    },
    {
      "title": "Demo 5: dapr.yaml",
      "icons": {
        "start": "code",
        "end": "pass-filled"
      },
      "steps": [
        {
          "action": "executeVSCodeCommand",
          "command": "workbench.action.focusSideBar"
        },
        {
          "action": "open",
          "path": "/Demo5/dapr.yaml"
        }
      ]
    },
    {
      "title": "Demo 5: Run Workflow",
      "icons": {
        "start": "terminal-cmd",
        "end": "pass-filled"
      },
      "steps": [
        {
          "action": "executeTerminalCommand",
          "command": "dapr run -f .",
          "terminalId": "dapr-run"
        }
      ]
    },
    {
      "title": "Demo 5: Call endpoints",
      "icons": {
        "start": "symbol-event",
        "end": "pass-filled"
      },
      "steps": [
        {
          "action": "highlight",
          "path": "/Demo5/demo5.http",
          "position": 5
        }
      ]
    },
    {
      "title": "Demo 5: Stop",
      "icons": {
        "start": "terminal-cmd",
        "end": "pass-filled"
      },
      "steps": [
        {
          "action": "focusTerminal",
          "terminalId": "dapr-run"
        },
        {
          "action": "sendKeybinding",
          "keybinding": "ctrl+C"
        },
        {
          "action": "executeTerminalCommand",
          "command": "cd ..",
          "terminalId": "dapr-run"
        },
        {
          "action": "executeTerminalCommand",
          "command": "clear",
          "terminalId": "dapr-run"
        }
      ]
    }
  ]
}
```

## Structure Reference (from 5-pubsub.json)

The file follows the same pattern as the Pub/Sub demo:

| Element | Description |
|---------|-------------|
| `$schema` | DemoTime schema URL |
| `title` | Demo title (e.g., "6 - Workflow") |
| `description` | Brief description of the demo |
| `version` | Schema version (2) |
| `demos` | Array of demo steps |

### Demo Step Actions Used

- `executeVSCodeCommand` - Run VS Code commands (kill terminals, close sidebar, focus sidebar)
- `openSlide` - Open a markdown slide
- `executeTerminalCommand` - Run terminal commands with a specific terminal ID
- `highlight` - Open a file and highlight a specific line
- `open` - Open a file in the editor
- `focusTerminal` - Focus a specific terminal
- `sendKeybinding` - Send a keyboard shortcut (e.g., ctrl+C to stop)

## Implementation Steps

1. Create `/.demo/slides/workflow.md` with the title slide content
2. Create `/.demo/slides/workflow-1.md` with the overview slide content
3. Create `/.demo/6-workflow.json` with the DemoTime configuration
4. Test by running the demo through the DemoTime extension

## Demo Flow Summary

1. **Workflow** - Kill terminals, close sidebar, show title slide
2. **Workflow Overview** - Show overview slide with key features
3. **WorkflowService Program.cs** - Highlight line 12 (Dapr Workflow registration), build the project
4. **ProfileWorkflow** - Show the workflow implementation file
5. **dapr.yaml** - Show the Dapr multi-app run configuration
6. **Run Workflow** - Start the application with `dapr run -f .`
7. **Call endpoints** - Show demo5.http to test the workflow endpoints
8. **Stop** - Stop the application with Ctrl+C and clean up
