import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import TaskForm from './TaskForm';

describe('TaskForm', () => {
    it('calls onAddTask with the correct data when form is submitted', () => {
        const mockOnAddTask = jest.fn();
        render(<TaskForm onAddTask={mockOnAddTask} />);

        const nameInput = screen.getByPlaceholderText('Nome do lembrete');
        const dateInput = screen.getByTestId('task-date');

        fireEvent.change(nameInput, { target: { value: 'New Task' } });
        fireEvent.change(dateInput, { target: { value: '2024-06-24' } });

        fireEvent.click(screen.getByText('Criar'));

        expect(mockOnAddTask).toHaveBeenCalledWith({
            name: 'New Task',
            date: '2024-06-24'
        });
    });
});
