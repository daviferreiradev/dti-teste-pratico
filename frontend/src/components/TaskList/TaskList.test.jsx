import React from 'react';
import { render, screen } from '@testing-library/react';
import TaskList from './TaskList';

describe('TaskList', () => {
    const tasks = [
        { id: 1, name: 'Task 1', date: '2024-06-24T20:41:27.519Z' }
    ];

    it('renders tasks grouped by date', () => {
        render(<TaskList tasks={tasks} onDeleteTask={() => { }} />);

        expect(screen.getByText('Task 1')).toBeInTheDocument();
        expect(screen.getByText(/24\/06\/2024/)).toBeInTheDocument();
    });
});
