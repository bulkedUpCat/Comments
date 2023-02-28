export class CommentModel{
  id!: string;
  userName!: string;
  text!: string;
  createdAt!: Date;
  parentCommentId!: string;
  replies!: CommentModel[];
}

export class CreateCommentModel{
  userName!: string;
  email!: string;
  text!: string;
  parentCommentId!: string;
}

export class CurrentComment{
  id!: string;
  type!: CurrentCommentType;
}

export enum CurrentCommentType{
  reply,
  edit
}
