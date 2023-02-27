import { NgModule } from '@angular/core';
import { CommentsListComponent } from './feature/comments-list/comments-list.component';
import { CommentItemComponent } from './feature/comment-item/comment-item.component';

@NgModule({
  declarations: [
    CommentsListComponent,
    CommentItemComponent
  ],
  imports: [
  ]
})
export class CommentsModule { }
