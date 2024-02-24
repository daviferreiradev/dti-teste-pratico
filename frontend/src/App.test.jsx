import React from 'react'; 
jest.mock('axios');

import axios from 'axios';
import { render, screen, waitFor } from '@testing-library/react';
import App from './App';

const mockedAxios = axios;

describe('App component', () => {
    it('fetches tasks on mount', async () => {
        mockedAxios.get.mockResolvedValueOnce({ data: [{ id: 1, name: 'Test Task', date: '2022-01-01' }] });

        render(<App />);

        await waitFor(() => expect(mockedAxios.get).toHaveBeenCalled());

        expect(screen.getByText(/Lista de lembretes/i)).toBeInTheDocument();
    });
});
