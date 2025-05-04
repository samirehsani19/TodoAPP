// using this hook to split the layer between api service and the UI components

import {useState, useEffect} from 'react';
import {getTodos, addTodo, deleteTodo} from '../services/todoService';

const useTodos = () => {
    const [todos, setTodos] = useState([]);

    useEffect(()=> {
        loadTodos();
    }, []);

    const loadTodos = async ()=> {
        const todos = await getTodos();
        setTodos(todos);
    };

    const handleAdd = async (todo)=> {
        const newTodo = await addTodo(todo);
        setTodos([...todos, newTodo]);
    };

    const handleDelete = async (id)=> {
        await deleteTodo(id);
        setTodos(todos.filter(t=> t.id !== id));
    };

    return {todos, handleAdd, handleDelete};
};

export default useTodos;