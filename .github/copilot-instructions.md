# Copilot Instructions

## Project Guidelines
- For parser performance work in this codebase, establish a profiling baseline before making optimizations; likely hotspots include per-line splitting in Parser/W3CItemsParser.cs, reflection via FieldInfo.SetValue, header field binding in Parser/W3CFieldsParser.cs, and converter allocation/boxing behavior.