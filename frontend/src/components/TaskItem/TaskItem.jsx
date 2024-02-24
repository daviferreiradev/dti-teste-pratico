import React from 'react';
import styles from './TaskItem.module.scss';
import PropTypes from 'prop-types';

function TaskItem({ task, onDeleteTask }) {
    return (
        <li className={styles.taskItem}>
            {task.name}
            <button className={styles.deleteButton} onClick={() => onDeleteTask(task.id)}>Excluir</button>
        </li>
    );
}

TaskItem.propTypes = {
    task: PropTypes.shape({
        id: PropTypes.oneOfType([PropTypes.string, PropTypes.number]).isRequired,
        name: PropTypes.string.isRequired,
    }).isRequired,
    onDeleteTask: PropTypes.func.isRequired,
};

export default TaskItem;
