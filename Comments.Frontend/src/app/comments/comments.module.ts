import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommentItemComponent } from './feature/comment-item/comment-item.component';
import { CommentsListComponent } from './feature/comments-list/comments-list.component';



@NgModule({
  declarations: [
    CommentsListComponent,
    CommentItemComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CommentsModule { }
