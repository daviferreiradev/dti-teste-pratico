import React, { useState } from 'react';
import styles from './TaskForm.module.css';

function TaskForm({ onAddTask }) {
    const [nome, setNome] = useState('');
    const [data, setData] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        const agora = new Date();
        agora.setHours(0, 0, 0, 0);

        const year = data.split('-')[0];
        const month = data.split('-')[1] - 1;
        const day = data.split('-')[2];
        const dataTask = new Date(year, month, day);

        if (!nome || dataTask <= agora) {
            alert("Os campos devem ser preenchidos corretamente e a data deve ser futura.");
            return;
        }

        onAddTask({ nome, data: dataTask.toISOString().split('T')[0] });
        setNome('');
        setData('');
    };


    return (
        <form onSubmit={handleSubmit} className={styles.formContainer}>
            <input
                type="text"
                placeholder="Nome do lembrete"
                value={nome}
                onChange={(e) => setNome(e.target.value)}
                required
                className={styles.inputField}
            />
            <input
                type="date"
                value={data}
                onChange={(e) => setData(e.target.value)}
                required
                className={styles.inputField}
            />
            <button type="submit" className={styles.submitButton}>Criar</button>
        </form>
    );
}

export default TaskForm;
