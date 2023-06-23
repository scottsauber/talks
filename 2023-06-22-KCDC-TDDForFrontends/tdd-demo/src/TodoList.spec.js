import React from "react";
import { render, screen } from "@testing-library/react";
import { TodoList } from "./TodoList";
import userEvent from "@testing-library/user-event";

const groceryStoreTodo = {
    id: 1,
    title: "Grocery Store",
};
const cleanKitchenTodo = {
    id: 2,
    title: "Clean Kitchen",
};
const todoItems = [groceryStoreTodo, cleanKitchenTodo];

it("should display all to do items", () => {
    render(<TodoList todos={todoItems} />);

    expect(screen.getByText(groceryStoreTodo.title)).toBeInTheDocument();
    expect(screen.getByText(cleanKitchenTodo.title)).toBeInTheDocument();
});

it("should filter to do list items when search text matches the casing", () => {
    render(<TodoList todos={todoItems} />);

    const searchInput = screen.getByLabelText("Search");
    userEvent.type(searchInput, "Grocery");

    expect(screen.getByText(groceryStoreTodo.title)).toBeInTheDocument();
    expect(screen.queryByText(cleanKitchenTodo.title)).not.toBeInTheDocument();
});

it("should filter to do list items when search text does not match the casing", () => {
    render(<TodoList todos={todoItems} />);

    const searchInput = screen.getByLabelText("Search");
    userEvent.type(searchInput, "grocery");

    expect(screen.getByText(groceryStoreTodo.title)).toBeInTheDocument();
    expect(screen.queryByText(cleanKitchenTodo.title)).not.toBeInTheDocument();
});
