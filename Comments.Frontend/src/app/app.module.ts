import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommentsModule } from './comments/comments.module';
import { CommentsListComponent } from './comments/feature/comments-list/comments-list.component';

@NgModule({
  declarations: [
    AppComponent,
    CommentsListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommentsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
