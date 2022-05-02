import React, { useEffect, useState } from "react";

const TodoList = (props) => {
    const { todos } = props;
    const [searchText, setSearchText] = useState("");
    const [filteredTodos, setFilteredTodos] = useState([...todos]);

    useEffect(() => {
        setFilteredTodos(
            todos.filter((todo) =>
                todo.title.toLowerCase().includes(searchText.toLowerCase())
            )
        );
    }, [searchText, todos]);

    function handleSearchTextChange(event) {
        setSearchText(event.target.value);
    }

    return (
        <>
            <label htmlFor="search-text">Search</label>
            <input
                id="search-text"
                value={searchText}
                onChange={handleSearchTextChange}
            />
            <ul>
                {filteredTodos.map((todo) => (
                    <li key={todo.id}>{todo.title}</li>
                ))}
            </ul>
        </>
    );
};

export default TodoList;
