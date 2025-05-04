import React, { useState } from 'react';

function TodoForm({ onAdd }) {
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!title.trim() || !description.trim()) return;

    onAdd({ title, description });
    setTitle('');
    setDescription('');
  };

  return (
    <form onSubmit={handleSubmit} className='shadow'>
      <div className='input-container'>
        <input
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          placeholder='Enter title'
          required
        />
        <input
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          placeholder='Enter description'
          required
        />
        <button type='submit' className='todoBtn'>Add Todo</button>
      </div>
    </form>
  );
}

export default TodoForm;
