import { render, screen, fireEvent } from '@testing-library/react';
import TaskForm from './TaskForm';

test('submete dados válidos através do TaskForm', () => {
    const mockOnAddTask = jest.fn();
    render(<TaskForm onAddTask={mockOnAddTask} />);

    fireEvent.change(screen.getByPlaceholderText(/nome do lembrete/i), { target: { value: 'Nova Tarefa' } });
    fireEvent.change(screen.getByPlaceholderText('Nome do lembrete'), { target: { value: '2023-01-01' } });
    fireEvent.click(screen.getByText(/criar/i));

    expect(mockOnAddTask).toHaveBeenCalledWith({
        nome: 'Nova Tarefa',
        data: expect.any(String), // Aqui você pode ajustar conforme a lógica de formatação de data
    });
});
