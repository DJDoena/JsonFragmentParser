# JSON Fragment Parser

A lightweight .NET library that extracts complete JSON fragments from the beginning of text strings. The parser intelligently stops once it finds a complete, valid JSON object or array, making it ideal for processing streams, logs, or any text containing JSON followed by additional content.

## Key Features

- **Smart Extraction**: Processes text from the start and stops immediately after finding a complete JSON fragment
- **Handles Large Text**: Efficiently extracts JSON from the beginning of very long strings without processing unnecessary content
- **Fragment Extraction**: Extract complete JSON objects or arrays from within larger text content
- **Tree Navigation**: Transform parsed JSON into a navigable tree structure
- **Multi-Framework Support**: Compatible with .NET Standard 2.0, .NET Framework 4.7.2, and .NET 10
- **Easy Integration**: Simple API for quick integration into your projects
- **Robust Parsing**: Built on top of Newtonsoft.Json for reliable JSON processing

## Installation

Install the package via NuGet Package Manager:

```
Install-Package DoenaSoft.JsonFragmentParser
```

Or via .NET CLI:

```
dotnet add package DoenaSoft.JsonFragmentParser
```

## Usage

### Basic Example - Extracting from Longer Text

```csharp
using DoenaSoft.JsonFragmentParser;

// The parser stops after finding the complete JSON object,
// ignoring any trailing content
string text = "{ \"name\": \"John\", \"age\": 30 } this text is ignored";

var parser = new EndOfJsonParser();
string jsonFragment = parser.GetJson(text);
// Result: { "name": "John", "age": 30 }

// Works with very long strings - only processes until JSON is complete
string longText = "{ \"data\": \"value\" }" + new string('x', 1000000);
string extracted = parser.GetJson(longText);
// Efficiently extracts just: { "data": "value" }
```

### Extracting JSON Objects

```csharp
// Text with embedded JSON object followed by additional content
string content = "Response: { \"status\": \"success\", \"data\": { \"id\": 123 } } Connection closed";

// Parser extracts only the complete JSON, stopping at the closing brace
var parser = new EndOfJsonParser();
string json = parser.GetJson(content);
// Result: { "status": "success", "data": { "id": 123 } }
```

### Extracting JSON Arrays

```csharp
// Text with embedded JSON array followed by more text
string content = "Items: [ { \"id\": 1 }, { \"id\": 2 } ] Total: 2 items";

// Parser stops after the complete array
var parser = new EndOfJsonParser();
string json = parser.GetJson(content);
// Result: [ { "id": 1 }, { "id": 2 } ]
```

## Use Cases

- **Stream Processing**: Extract JSON from the beginning of streaming data without reading the entire stream
- **Log Parsing**: Extract JSON data from log files that contain mixed text and JSON content, stopping at fragment boundaries
- **API Response Processing**: Parse JSON fragments from partial responses or chunked transfer encoding
- **Data Mining**: Extract structured JSON data from unstructured text sources where JSON may be followed by arbitrary content
- **Configuration Parsing**: Read JSON configuration blocks embedded at the start of larger configuration files
- **Message Processing**: Parse JSON payloads from message streams where multiple messages are concatenated

## Requirements

- .NET Standard 2.0 or higher
- .NET Framework 4.7.2 or higher
- .NET 10 or higher
- Newtonsoft.Json 13.0.4 or higher

## Project Structure

The library is built as a single assembly targeting multiple frameworks, ensuring broad compatibility across different .NET platforms.

## Contributing

Contributions are welcome! Please feel free to submit issues, fork the repository, and create pull requests.

## License

This project is licensed under the MIT License. See the LICENSE file for details.

## Links

- **GitHub Repository**: https://github.com/DJDoena/JsonFragmentParser
- **NuGet Package**: https://www.nuget.org/packages/DoenaSoft.JsonFragmentParser

## Author

DJ Doena (Doena Soft.)

## Version History

### 1.0.1
- Current stable release
- Multi-framework targeting support
- Core JSON fragment extraction and parsing functionality

## Support

For bug reports, feature requests, or questions, please open an issue on the GitHub repository.