import TaskItem from './TaskItem';
import styles from './TaskList.module.css';

function TaskList({ tasks, onDeleteTask }) {
    function formatDate(dateString) {
        const options = { year: 'numeric', month: '2-digit', day: '2-digit' };
        return new Date(dateString).toLocaleDateString('pt-BR', options);
    }

    // Agrupando Tasks por data
    const tasksPorData = tasks.reduce((acc, task) => {
        (acc[task.date] = acc[task.date] || []).push(task);
        return acc;
    }, {});

    // Ordenando as datas
    const datasOrdenadas = Object.keys(tasksPorData).sort();

    return (
        <div>
            {datasOrdenadas.map((date) => (
                <div key={date}>
                    <h2>{formatDate(date)}</h2>
                    <ul className={styles.taskList}>
                        {tasksPorData[date].map((task) => (
                            <TaskItem key={task.id} task={task} onDeleteTask={onDeleteTask} />
                        ))}
                    </ul>
                </div>
            ))}
        </div>
    );
}

export default TaskList;
