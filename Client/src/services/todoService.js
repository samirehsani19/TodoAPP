// todoService responsible for handling api calls

import axios from 'axios';

const API_URL = "https://localhost:5002/api/todos";

export const getTodos = () => axios.get(API_URL).then(res => res.data);
export const addTodo = (todo) => axios.post(API_URL, todo).then(res => res.data);
export const deleteTodo = (id) => axios.delete(`${API_URL}/${id}`);
