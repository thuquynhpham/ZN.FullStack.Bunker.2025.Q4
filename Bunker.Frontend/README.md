# Bunker Management System - Frontend

A Vue.js 3 frontend application for managing vessels, ports, voyages, and bunker orders.

## Features

- **Vessel Management**: Create, read, update, and delete vessel information
- **Modern UI**: Clean and responsive design with Vue 3 Composition API
- **TypeScript**: Full TypeScript support for better development experience
- **State Management**: Pinia store for efficient state management
- **Routing**: Vue Router for navigation
- **API Integration**: Axios for HTTP requests

## Technology Stack

- Vue 3 with Composition API
- TypeScript
- Pinia (State Management)
- Vue Router
- Axios (HTTP Client)
- Vite (Build Tool)
- ESLint (Code Linting)

## Project Structure

```
src/
├── components/          # Reusable Vue components
├── views/              # Page components
├── stores/             # Pinia stores
├── services/           # API services
├── types/              # TypeScript type definitions
├── router/             # Vue Router configuration
└── assets/             # Static assets
```

## Getting Started

### Prerequisites

- Node.js (v18 or higher)
- npm or yarn

### Installation

1. Install dependencies:
```bash
npm install
```

2. Start the development server:
```bash
npm run dev
```

3. Build for production:
```bash
npm run build
```

## API Configuration

The application is configured to proxy API requests to `http://localhost:5000`. Update the proxy configuration in `vite.config.ts` if your backend runs on a different port.

## Development

- `npm run dev` - Start development server
- `npm run build` - Build for production
- `npm run preview` - Preview production build
- `npm run lint` - Run ESLint
- `npm run type-check` - Run TypeScript type checking

## Vessel Management

The application includes comprehensive vessel management features:

- **Vessel List**: View all vessels with pagination and filtering
- **Vessel Details**: Detailed view of vessel information
- **Create Vessel**: Add new vessels with validation
- **Edit Vessel**: Update existing vessel information
- **Delete Vessel**: Remove vessels with confirmation

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Run tests and linting
5. Submit a pull request
