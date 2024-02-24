import TaskItem from './TaskItem';
import styles from './TaskList.module.css';

function TaskList({ tasks, onDeleteTask }) {
    function formatDate(dateString) {
        const options = { year: 'numeric', month: '2-digit', day: '2-digit' };
        return new Date(dateString).toLocaleDateString('pt-BR', options);
    }

    // Agrupando Tasks por data
    const tasksPorData = tasks.reduce((acc, task) => {
        (acc[task.data] = acc[task.data] || []).push(task);
        return acc;
    }, {});

    // Ordenando as datas
    const datasOrdenadas = Object.keys(tasksPorData).sort();

    return (
        <div>
            {datasOrdenadas.map((data) => (
                <div key={data}>
                    <h2>{formatDate(data)}</h2>
                    <ul className={styles.taskList}>
                        {tasksPorData[data].map((task) => (
                            <TaskItem key={task.id} task={task} onDeleteTask={onDeleteTask} />
                        ))}
                    </ul>
                </div>
            ))}
        </div>
    );
}

export default TaskList;
