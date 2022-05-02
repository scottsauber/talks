import React from "react";
import { render, screen } from "@testing-library/react";
import TodoList from "./TodoList";
import userEvent from "@testing-library/user-event";

const groceryStore = {
    id: 1,
    title: "Grocery Store",
};
const cleanKitchen = {
    id: 2,
    title: "Clean Kitchen",
};
const todos = [groceryStore, cleanKitchen];

it("should display all the to do items", () => {
    render(<TodoList todos={todos} />);

    expect(screen.getByText(groceryStore.title)).toBeInTheDocument();
    expect(screen.getByText(cleanKitchen.title)).toBeInTheDocument();
});

it("should filter results when search text is case sensitive", () => {
    render(<TodoList todos={todos} />);

    const searchInput = screen.getByLabelText("Search");
    userEvent.type(searchInput, "Grocery");

    expect(screen.getByText(groceryStore.title)).toBeInTheDocument();
    expect(screen.queryByText(cleanKitchen.title)).not.toBeInTheDocument();
});

it("should filter results when search text is case insensitive", () => {
    render(<TodoList todos={todos} />);

    const searchInput = screen.getByLabelText("Search");
    userEvent.type(searchInput, "grocery");

    expect(screen.getByText(groceryStore.title)).toBeInTheDocument();
    expect(screen.queryByText(cleanKitchen.title)).not.toBeInTheDocument();
});
