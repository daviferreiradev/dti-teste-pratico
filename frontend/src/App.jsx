import { useState, useEffect } from 'react';
import axios from 'axios';
import TaskForm from './components/TaskForm';
import TaskList from './components/TaskList';
import styles from './App.module.css';

function App() {
    const [tasks, setTasks] = useState([]);

    useEffect(() => {
        fetchTasks();
    }, []);


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
                const createdTask = response.data;
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
