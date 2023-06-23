import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { TodoList } from "./TodoList";

const root = ReactDOM.createRoot(document.getElementById("root"));
const groceryStore = {
    id: 1,
    title: "Grocery Store",
};
const cleanKitchen = {
    id: 2,
    title: "Clean Kitchen",
};
const todos = [groceryStore, cleanKitchen];
root.render(
    <React.StrictMode>
        <TodoList todos={todos} />
    </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
