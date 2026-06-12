<script setup lang="ts">
import { computed } from 'vue'
import { Eye, EyeOff, MessageSquareText, Plus, RefreshCw, Trash2 } from 'lucide-vue-next'
import type { WriterComment, WriterCommentVisibility } from '../../utils/writerControlAdapter'

interface Props {
  comments: readonly WriterComment[]
  visibility: WriterCommentVisibility
  canUseComments: boolean
  errorMessage?: string | null
}

interface Emits {
  addComment: []
  refreshComments: []
  deleteCurrentComment: []
  visibilityChange: [visibility: WriterCommentVisibility]
}

const props = defineProps<Props>()
const emit = defineEmits<Emits>()

const visibilityOptions: Array<{
  value: WriterCommentVisibility
  label: string
  title: string
}> = [
  { value: 'Visible', label: '总是显示', title: '总是显示批注' },
  { value: 'Auto', label: '自动', title: '自动显示批注' },
  { value: 'Hide', label: '隐藏', title: '隐藏批注' },
]

const commentCountText = computed(() => String(props.comments.length))

function commentKey(comment: WriterComment, index: number) {
  return String(comment.Index ?? `${comment.AuthorID || comment.Author || 'comment'}-${index}`)
}

function commentAuthor(comment: WriterComment) {
  return String(comment.Author || comment.author || comment.AuthorID || 'DCWriter')
}

function commentText(comment: WriterComment) {
  return String(comment.Text || '')
}

function commentTone(comment: WriterComment) {
  const source = comment.Attributes?.source
  if (source === 'validation' || comment.AuthorID === 'validation') {
    return 'writer-comments__item--validation'
  }

  return 'writer-comments__item--manual'
}
</script>

<template>
  <section class="writer-comments" aria-label="原生批注">
    <div class="writer-comments__header">
      <div class="writer-comments__title">
        <MessageSquareText :size="16" aria-hidden="true" />
        <span>原生批注</span>
        <strong>{{ commentCountText }}</strong>
      </div>

      <div class="writer-comments__tools">
        <button
          class="writer-comments__icon-button"
          type="button"
          title="新增批注"
          :disabled="!props.canUseComments"
          @click="emit('addComment')"
        >
          <Plus :size="14" aria-hidden="true" />
        </button>
        <button
          class="writer-comments__icon-button"
          type="button"
          title="刷新批注"
          :disabled="!props.canUseComments"
          @click="emit('refreshComments')"
        >
          <RefreshCw :size="14" aria-hidden="true" />
        </button>
        <button
          class="writer-comments__icon-button"
          type="button"
          title="删除当前批注"
          :disabled="!props.canUseComments || props.comments.length === 0"
          @click="emit('deleteCurrentComment')"
        >
          <Trash2 :size="14" aria-hidden="true" />
        </button>
      </div>
    </div>

    <div class="writer-comments__visibility" role="group" aria-label="批注显示方式">
      <button
        v-for="option in visibilityOptions"
        :key="option.value"
        class="writer-comments__visibility-button"
        :class="{ 'writer-comments__visibility-button--active': option.value === props.visibility }"
        type="button"
        :title="option.title"
        :disabled="!props.canUseComments"
        @click="emit('visibilityChange', option.value)"
      >
        <EyeOff v-if="option.value === 'Hide'" :size="13" aria-hidden="true" />
        <Eye v-else :size="13" aria-hidden="true" />
        <span>{{ option.label }}</span>
      </button>
    </div>

    <p v-if="props.errorMessage" class="writer-comments__error">{{ props.errorMessage }}</p>

    <div v-if="props.comments.length > 0" class="writer-comments__list">
      <article
        v-for="(comment, index) in props.comments"
        :key="commentKey(comment, index)"
        class="writer-comments__item"
        :class="commentTone(comment)"
      >
        <div class="writer-comments__item-meta">
          <span>{{ commentAuthor(comment) }}</span>
          <small v-if="comment.CreationTime">{{ comment.CreationTime }}</small>
        </div>
        <p class="writer-comments__item-text">{{ commentText(comment) }}</p>
      </article>
    </div>

    <p v-else class="writer-comments__empty">暂无批注</p>
  </section>
</template>

<style scoped>
.writer-comments {
  display: grid;
  max-height: 196px;
  min-height: 0;
  grid-template-rows: 34px 32px auto minmax(0, 1fr);
  border-top: 1px solid #b9c8d6;
  background: #f8fbfd;
  color: #263648;
}

.writer-comments__header {
  display: flex;
  min-width: 0;
  align-items: center;
  justify-content: space-between;
  gap: 10px;
  padding: 0 10px 0 12px;
  border-bottom: 1px solid #d7e1ea;
}

.writer-comments__title {
  display: inline-flex;
  min-width: 0;
  align-items: center;
  gap: 7px;
  font-size: 13px;
  font-weight: 700;
}

.writer-comments__title strong {
  display: inline-flex;
  min-width: 22px;
  height: 20px;
  align-items: center;
  justify-content: center;
  border-radius: 8px;
  background: #dfe8f1;
  color: #1f4f73;
  font-size: 12px;
}

.writer-comments__tools {
  display: inline-flex;
  flex: 0 0 auto;
  gap: 4px;
}

.writer-comments__icon-button {
  display: inline-flex;
  width: 24px;
  height: 24px;
  align-items: center;
  justify-content: center;
  border: 1px solid transparent;
  border-radius: 5px;
  background: transparent;
  color: #40566d;
}

.writer-comments__icon-button:hover:not(:disabled) {
  border-color: #b8c8d8;
  background: #e9f1f8;
}

.writer-comments__icon-button:disabled {
  color: #9aaabd;
  cursor: not-allowed;
}

.writer-comments__visibility {
  display: grid;
  min-width: 0;
  grid-template-columns: repeat(3, minmax(0, 1fr));
  gap: 4px;
  padding: 5px 10px;
  border-bottom: 1px solid #d7e1ea;
}

.writer-comments__visibility-button {
  display: inline-flex;
  min-width: 0;
  height: 22px;
  align-items: center;
  justify-content: center;
  gap: 4px;
  overflow: hidden;
  border: 1px solid #bfd0df;
  border-radius: 5px;
  background: #ffffff;
  color: #40566d;
  font-size: 12px;
  white-space: nowrap;
}

.writer-comments__visibility-button:hover:not(:disabled),
.writer-comments__visibility-button--active {
  border-color: #5f77d6;
  background: #edf0ff;
  color: #253c96;
}

.writer-comments__visibility-button:disabled {
  color: #9aaabd;
  cursor: not-allowed;
}

.writer-comments__error {
  margin: 0;
  padding: 6px 12px;
  border-bottom: 1px solid #f0c36d;
  background: #fff8e6;
  color: #9a3412;
  font-size: 12px;
  line-height: 18px;
}

.writer-comments__list {
  min-height: 0;
  overflow: auto;
  padding: 8px 10px 10px;
}

.writer-comments__item {
  display: grid;
  gap: 4px;
  padding: 8px 9px;
  border: 1px solid #c8d5e0;
  border-left-width: 4px;
  border-radius: 7px;
  background: #ffffff;
}

.writer-comments__item + .writer-comments__item {
  margin-top: 6px;
}

.writer-comments__item--validation {
  border-left-color: #6d70d9;
  background: #f4f5ff;
}

.writer-comments__item--manual {
  border-left-color: #dc4c4c;
  background: #fff6f4;
}

.writer-comments__item-meta {
  display: flex;
  min-width: 0;
  align-items: center;
  gap: 8px;
  color: #2e4054;
  font-size: 12px;
  font-weight: 700;
}

.writer-comments__item-meta small {
  min-width: 0;
  overflow: hidden;
  color: #718399;
  font-size: 11px;
  font-weight: 400;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.writer-comments__item-text {
  margin: 0;
  overflow: hidden;
  color: #314256;
  font-size: 12px;
  line-height: 18px;
  overflow-wrap: anywhere;
  white-space: pre-line;
}

.writer-comments__empty {
  margin: 0;
  padding: 14px 12px;
  color: #6b7f93;
  font-size: 12px;
}
</style>
