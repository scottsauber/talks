import React, { useEffect, useState } from "react";

export const TodoList = (props) => {
    const [searchText, setSearchText] = useState("");
    const filteredTodos = props.todos.filter((todo) =>
        todo.title.toLowerCase().includes(searchText.toLowerCase())
    );

    function handleSearchTextChange(event) {
        setSearchText(event.target.value);
    }

    return (
        <>
            <label htmlFor="search-input">Search</label>
            <input
                id="search-input"
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
