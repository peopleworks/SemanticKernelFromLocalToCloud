# Semantic Kernel From Local To Cloud

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#)

Integrate Semantic Kernel services across local and remote providers using a unified codebase. Seamlessly switch between providers like Ollama, phi3.5, llama3.2, Azure, OpenAI, Google Gemini, and Groq by simply changing the service name. Leverage function calling and memory with all supported models.

## Table of Contents

- [About the Project](#about-the-project)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)
- [Acknowledgments](#acknowledgments)

---

## About the Project

This project showcases how to use Microsoft's Semantic Kernel with both **local** (Ollama, phi3.5, llama3.2) and **remote** services (Azure, OpenAI, Google Gemini, Groq) using the same codebase. By simply changing the service name, you can switch between different AI providers without altering your core logic.

## Features

- **Unified Kernel Creation**: Integrate all Semantic Kernel services using a single kernel setup.
- **Multi-Provider Support**: Seamlessly switch between local and remote AI models.
- **Function Calling**: Utilize function calling capabilities across all supported models.
- **Memory Integration**: Implement memory functions with ease.
- **Extensible Architecture**: Easily expand to support more providers and functionalities.

## Getting Started

### Prerequisites

- **Development Environment**: Visual Studio or Visual Studio Code
- **.NET SDK**: Ensure you have the latest .NET SDK installed
- **API Keys**: Obtain API keys for the services you wish to use

### Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/peopleworks/SemanticKernelFromLocalToCloud.git
   ```
2. **Open the Project**
   - Navigate to the project directory and open it in Visual Studio or Visual Studio Code.
3. **Update API Keys**
   - Locate the `appsettings.json` file.
   - Update the `ApiKeys` section with your respective API keys.
4. **Run the Application**
   - Use your IDE's build and run feature to start the application.

## Usage

- **Switch Providers**
  - Change the service name in the configuration to switch between different AI models.
- **Function Calling**
  - Utilize the function calling feature as documented in Semantic Kernel.
- **Memory Features**
  - Implement and test memory functionalities across different models.

## Roadmap

- **Upcoming Features**
  - Adding Retrieval-Augmented Generation (RAG) for both local and remote models.
  - Implementing additional functions and enhancements in the next version.

Stay tuned for more exciting updates!

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. **Fork the Project**
2. **Create your Feature Branch** (`git checkout -b feature/AmazingFeature`)
3. **Commit your Changes** (`git commit -m 'Add some AmazingFeature'`)
4. **Push to the Branch** (`git push origin feature/AmazingFeature`)
5. **Open a Pull Request**

## License

Distributed under the **MIT License**. See `LICENSE` file for more information.

## Contact

- **Email**: [peopleworks@gmail.com](mailto:peopleworks@gmail.com)

## Acknowledgments

- **Microsoft® Semantic Kernel Team**: For their outstanding work.
- **Ollama**: For providing an excellent tool.
- **Google**: For their fast and well-crafted models.
- **Groq**: For being a part of the developer community.
- **Meta**: For supporting open-source initiatives.




<a href="https://next.ossinsight.io/widgets/official/compose-last-28-days-stats?repo_id=41986369" target="_blank" style="display: block" align="center">
  <picture>
    <source media="(prefers-color-scheme: dark)" srcset="https://next.ossinsight.io/widgets/official/compose-last-28-days-stats/thumbnail.png?repo_id=41986369&image_size=auto&color_scheme=dark" width="655" height="auto">
    <img alt="Performance Stats of pingcap/tidb - Last 28 days" src="https://next.ossinsight.io/widgets/official/compose-last-28-days-stats/thumbnail.png?repo_id=41986369&image_size=auto&color_scheme=light" width="655" height="auto">
  </picture>
</a>


---

*This README was generated to provide a comprehensive overview of the project, aiming to assist developers and contributors in understanding and utilizing the Semantic Kernel across various platforms.*
