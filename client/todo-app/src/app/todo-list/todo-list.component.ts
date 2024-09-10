import { Component, OnInit } from '@angular/core';
import { TodoService } from '../todo.service';
import { TodoItem } from '../todo-item.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './todo-list.component.html',
  styleUrl: './todo-list.component.css'
})
export class TodoListComponent implements OnInit {

  todos: TodoItem[] = [];
  editingId = null;
  editName = '';
  newTodo: TodoItem = { id: 0, name: '', isCompleted: false };

  constructor(private todoService: TodoService) { }

  ngOnInit(): void {
    this.loadTodos();
  }

  loadTodos(): void {
    this.todoService.getTodos().subscribe(todos => this.todos = todos)
  }

  addTodo(): void {
    if (this.newTodo.name.trim()) {
      this.todoService.addTodo(this.newTodo).subscribe(() => {
        this.loadTodos();
        this.newTodo = { id: 0, name: '', isCompleted: false };
      });
    }
  }

  editTodo(todo: any): void {
    this.editingId = todo.id;
    this.editName = todo.name;
  }

  updateTodo(todo: any): void {
    this.todoService.updateTodo(todo).subscribe(() => {
      this.editingId = null;
      this.editName = '';
    });
  }

  cancelEdit(todo: any): void {
    todo.name = this.editName;
    this.editingId = null;
    this.editName = '';

  }

  deleteTodo(id: number): void {
    this.todoService.deleteTodo(id).subscribe(() => this.loadTodos());
  }

}
