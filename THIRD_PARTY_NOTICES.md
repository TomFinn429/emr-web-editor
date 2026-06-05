# Third-Party Notices

This file summarizes third-party components that are visible from this
repository's package manifests. It is not a substitute for the full license text
provided by each upstream project.

## Frontend Runtime And Tooling

| Component | Purpose | License |
| --- | --- | --- |
| Vue | Frontend framework | MIT |
| Element Plus | UI component library | MIT |
| lucide-vue-next | Icon components | ISC |
| Vite | Frontend build tool and dev server | MIT |
| @vitejs/plugin-vue | Vue plugin for Vite | MIT |
| TypeScript | TypeScript compiler | Apache-2.0 |
| vue-tsc | Vue TypeScript type checking | MIT |
| Vitest | Test runner | MIT |

The transitive frontend dependency tree also includes packages under licenses
such as MIT, Apache-2.0, BSD-2-Clause, BSD-3-Clause, ISC, 0BSD, and MPL-2.0,
as recorded in `frontend/package-lock.json`.

## Backend Runtime And Tooling

| Component | Purpose | License |
| --- | --- | --- |
| .NET / ASP.NET Core | Backend runtime and Minimal API framework | MIT |
| Microsoft.AspNetCore.OpenApi | OpenAPI support for ASP.NET Core | MIT |

## Optional Third-Party Rendering Resources

The repository contains configuration and adapter code that can serve optional
local rendering resources from paths such as:

```text
backend/renderer-source/
backend/renderer-runtime/
backend/renderer-assets/
```

The Apache-2.0 license for this repository does not grant any rights to
DCWriter, WriterControl, DCSoft, EMRWriterLite, commercial editor runtimes,
reverse-engineered binaries, decompiled source code, proprietary templates, or
other third-party materials. Use, copying, modification, distribution, and
deployment of those materials must be covered by a separate valid authorization
from the corresponding rights holder.
