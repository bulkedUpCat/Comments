import { Component, Input, OnInit } from '@angular/core';
import { CommentModel } from 'src/app/models/comment';

@Component({
  selector: 'comment-item',
  templateUrl: './comment-item.component.html',
  styleUrls: ['./comment-item.component.scss']
})
export class CommentItemComponent implements OnInit {
  @Input() comment!: CommentModel;

  canReply: boolean = true;
  canEdit: boolean = true;
  canDelete: boolean = true;

  constructor() { }

  ngOnInit(): void {
  }

}
