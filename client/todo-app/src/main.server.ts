import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { config } from './app/app.config.server';
import { TodoListComponent } from './app/todo-list/todo-list.component'

const bootstrap = () => bootstrapApplication(TodoListComponent, config);

export default bootstrap;
