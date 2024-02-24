import styles from './TaskItem.module.css';

function TaskItem({ task, onDeleteTask }) {
    return (
        <li className={styles.taskItem}>
            {task.name}
            <button className={styles.deleteButton} onClick={() => onDeleteTask(task.id)}>Excluir</button>
        </li>
    );
}

export default TaskItem;
