# .NET Developer Take-Home Test: AI-Assisted Port Calls API

This is a practical test to assess your modern development workflow. The goal is to demonstrate how you leverage **AI development tools** to efficiently build a well-structured **.NET Minimal API** and a simple **Angular** frontend.

The primary focus is on your ability to direct, refine, and validate AI-generated code. **You are not required to deliver a fully runnable application**, but rather a well-structured codebase with clear examples of code and tests.

Please fork this repo and share a PR.

You do not need to deliver it all, please take your own time into consideration, however fokus on providing something special that we can talk about later at our following interviews.


-----

## The Core Task: What to Build

Design and partially implement the components for a shipping logistics application.

### Backend (.NET Minimal API)

  * **Data Model**: Define entities for `Vessel`, `Port`, `Voyage`, `PortCall`, and `BunkerOrder`. Use either **EF Core** or **Dapper**.
  * **API Logic**: Structure the Minimal API endpoints for at least one full CRUD operation (e.g., for `PortCall`). Implement the logic for a list endpoint with filtering (e.g., by date range and status).
  * **Backend Testing (Required)** ✅:
      * Provide one **unit test** for a piece of business logic.
      * Provide one **integration test** for an API endpoint using `WebApplicationFactory`.

### Frontend (Angular)

  * **Component Structure**: Create the core components and services (e.g., `PortCallListComponent`, `PortCallService`).
  * **UI Logic**: The component and service code should demonstrate how you would manage state, handle user events (like filtering), and interact with the backend API.
  * **Frontend Testing (Required)** ✅:
      * Provide one **component test** (using Jasmine/Karma or similar) that verifies rendering and basic interaction.

-----

## The Development Process: How to Build It (AI-Driven)

This test is designed to evaluate your skill in using AI as a development partner.

### AI-Driven Development (Required) 🤖

You can and should use an AI assistant (e.g., **GitHub Copilot, Gemini, ChatGPT, Claude, Cursor**) for this task. We want to see how you apply an **Iterative AI-Driven Development (IDD)** approach:

1.  **Prompt**: Formulate clear prompts to generate code, tests, documentation, or project structure.
2.  **Review & Refine**: Critically evaluate the AI's output for correctness, style, and adherence to best practices.
3.  **Integrate**: Integrate the refined code into your project.

While the AI writes the code, **you are the architect and quality gatekeeper**. Your final submission should reflect professional-quality code that you are confident in shipping.

### Documentation with AI

Your `README.md` file should also be co-authored with an AI. Use it to generate project descriptions, setup instructions, and examples based on the codebase.

-----

## Submission Requirements

Please share a **private GitHub repository** with us containing your solution.

### 1\. Codebase

  * A single repository with separate folders for the backend (`/api`) and frontend (`/ui`).
  * The code should be well-structured and include the required testing examples.

### 2\. README.md

  * An AI-assisted `README.md` file that includes:
      * A brief description of the project architecture and key decisions.
      * Clear instructions on how to run the backend and frontend **tests**.
      * Code snippets or `cURL` examples showing how the final API *would* be used.

### 3\. AGENTS.md (Required) 📝

  * You must include a file named `AGENTS.md` at the root of your repository.
  * This file will serve as a log of your development process, documenting the key conversations you had with your AI assistant(s).
  * **Format**: Use the [AGENTS.md standard](https://www.google.com/search?q=https://github.com/AI-Engineers/AGENTS/blob/main/AGENTS.md), which involves simple markdown to log your prompts and the AI's responses. This helps us understand your thought process and how you effectively guide AI tools to achieve your goals.
