import { render, screen, fireEvent } from '@testing-library/react';
import TaskForm from './TaskForm';

test('submete dados v�lidos atrav�s do TaskForm', () => {
    const mockOnAddTask = jest.fn();
    render(<TaskForm onAddTask={mockOnAddTask} />);

    fireEvent.change(screen.getByPlaceholderText(/nome do lembrete/i), { target: { value: 'Nova Tarefa' } });
    fireEvent.change(screen.getByPlaceholderText('Nome do lembrete'), { target: { value: '2023-01-01' } });
    fireEvent.click(screen.getByText(/criar/i));

    expect(mockOnAddTask).toHaveBeenCalledWith({
        nome: 'Nova Tarefa',
        data: expect.any(String), // Aqui voc� pode ajustar conforme a l�gica de formata��o de data
    });
});
