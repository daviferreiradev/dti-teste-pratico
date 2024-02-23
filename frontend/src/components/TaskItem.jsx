import React from 'react';
import styles from './TaskItem.module.css';

function TaskItem({ task, onDeleteTask }) {
    return (
        <li className={styles.taskItem}>
            {task.nome}
            <button className={styles.deleteButton} onClick={() => onDeleteTask(task.id)}>Excluir</button>
        </li>
    );
}

export default TaskItem;
