import React from 'react';
import useTodos from './hooks/useTodo';
import TodoItem from './components/todoItem';
import TodoForm from './components/todoForm';
import './styles/todo.css';

function App(){
  const {todos, handleAdd, handleDelete} = useTodos();
 
  return (
    <div className='app'>
      <div className='todo-container shadow'>
        <h1>Todo List</h1>
        <TodoForm onAdd={handleAdd} />

        <div className='todo-list'>
          {todos.map(todo => (
            <TodoItem key={todo.id} todo={todo} onDelete={handleDelete} />
          ))}
        </div>
      </div>
    </div>
  );
}

export default App;