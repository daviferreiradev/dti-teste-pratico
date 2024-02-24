/**
 * For a detailed explanation regarding each configuration property, visit:
 * https://jestjs.io/docs/configuration
 */

/** @type {import('jest').Config} */
const config = {
    clearMocks: true,
    collectCoverage: true,
    coverageDirectory: "coverage",
    coverageProvider: "v8",
    moduleNameMapper: {
        '\\.(css|less)$': '<rootDir>/__mocks__/styleMock.js',
    },
    testEnvironment: "jsdom",

    // The paths to modules that run some code to configure or set up the testing framework before each test
    setupFilesAfterEnv: ['<rootDir>/jest.setup.js'],

    // The glob patterns Jest uses to detect test files
    testMatch: [
        "**/*.test.js?(x)",
    ],

    // A map from regular expressions to paths to transformers
    transform: {
        '^.+\\.jsx?$': 'babel-jest',
    },
};

export default config;
