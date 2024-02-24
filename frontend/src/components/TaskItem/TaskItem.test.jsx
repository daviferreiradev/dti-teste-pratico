import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import TaskItem from './TaskItem';

describe('TaskItem', () => {
    const task = { id: 1, name: 'Task Test' };
    const mockOnDeleteTask = jest.fn();

    it('displays task information', () => {
        render(<TaskItem task={task} onDeleteTask={mockOnDeleteTask} />);

        expect(screen.getByText('Task Test')).toBeInTheDocument();
    });

    it('calls onDeleteTask when delete button is clicked', () => {
        render(<TaskItem task={task} onDeleteTask={mockOnDeleteTask} />);

        fireEvent.click(screen.getByText(/Excluir/i));
        expect(mockOnDeleteTask).toHaveBeenCalledWith(1);
    });
});
