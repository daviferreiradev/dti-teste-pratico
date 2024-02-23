import React, { useState, useEffect } from 'react';
import axios from 'axios';
import TaskForm from './components/TaskForm';
import TaskList from './components/TaskList';
import styles from './App.module.css';

function App() {
    const [tasks, setTasks] = useState([]);

    useEffect(() => {
        fetchTasks();
    }, []); // Isso garante que fetchTasks seja chamado apenas na montagem do componente


    const fetchTasks = async () => {
        try {
            const response = await axios.get('http://localhost:5042/api/tarefa');
            setTasks(response.data);
        } catch (error) {
            console.error("Erro ao buscar tasks:", error);
        }
    };

    const addTask = async (newTask) => {
        try {
            const response = await axios.post('http://localhost:5042/api/tarefa', newTask);
            if (response.status === 201) {
                // Assume que a resposta da API inclui a tarefa criada
                const createdTask = response.data;
                // Atualiza o estado para incluir a nova tarefa
                setTasks(prevTasks => [...prevTasks, createdTask]);
            }
        } catch (error) {
            console.error("Erro ao adicionar task:", error);
        }
    };


    const deleteTask = async (id) => {
        try {
            const response = await axios.delete(`http://localhost:5042/api/tarefa/${id}`);
            if (response.status === 200) {
                // Atualize a lista de tarefas filtrando a tarefa excluída sem precisar recarregar
                setTasks(tasks.filter(task => task.id !== id));
            }
        } catch (error) {
            console.error("Erro ao excluir task:", error);
        }
    };

    return (
        <div className={styles.appContainer}>
            <h1>Novo lembrete</h1>
            <TaskForm onAddTask={addTask} />
            <h1>Lista de lembretes</h1>
            <TaskList tasks={tasks} onDeleteTask={deleteTask} />
        </div>
    );
}

export default App;
