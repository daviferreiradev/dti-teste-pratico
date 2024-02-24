import React,{ useState } from 'react';
import PropTypes from 'prop-types';
import styles from './TaskForm.module.scss';

function TaskForm({ onAddTask }) {
    const [name, setName] = useState('');
    const [date, setDate] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        const agora = new Date();
        agora.setHours(0, 0, 0, 0);

        const year = date.split('-')[0];
        const month = date.split('-')[1] - 1;
        const day = date.split('-')[2];
        const taskDate = new Date(year, month, day);

        if (!name || taskDate <= agora) {
            alert("Os campos devem ser preenchidos corretamente e a data deve ser futura.");
            return;
        }

        onAddTask({ name, date: taskDate.toISOString().split('T')[0] });
        setName('');
        setDate('');
    };


    return (
        <form onSubmit={handleSubmit} className={styles.formContainer}>
            <input
                type="text"
                placeholder="Nome do lembrete"
                value={name}
                onChange={(e) => setName(e.target.value)}
                required
                className={styles.inputField}
            />
            <input
                type="date"
                value={date}
                onChange={(e) => setDate(e.target.value)}
                required
                className={styles.inputField}
                data-testid="task-date"
            />
            <button type="submit" className={styles.submitButton}>Criar</button>
        </form>
    );
}

TaskForm.propTypes = {
    onAddTask: PropTypes.func.isRequired,
};

export default TaskForm;
