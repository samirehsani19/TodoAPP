// using this component to reuse it for displaying todos

const TodoItem = ({ todo, onDelete }) => {
    return (
      <div className="todo-item shadow">
        <h3>{todo.title}</h3>
        <p>{todo.description}</p>
        <button className="todoBtn danger" onClick={() => onDelete(todo.id)}>Delete</button>
      </div>
    );
  };
  
  export default TodoItem;
  