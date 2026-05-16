import { describe, expect, it } from 'vitest'
import { createWriterCommandPayload, findRibbonCommand, ribbonTabs } from './ribbonCommands'

describe('ribbonCommands', () => {
  it('contains required tabs', () => {
    expect(ribbonTabs.map(tab => tab.id)).toEqual(['file', 'start', 'insert', 'table', 'print'])
  })

  it('maps bold to a DC command', () => {
    expect(createWriterCommandPayload('bold')).toEqual({
      commandName: 'bold',
      showUI: false,
      parameter: true,
      executor: 'dc',
    })
  })

  it('maps split cell to the DC command executor', () => {
    expect(createWriterCommandPayload('splitCell')).toEqual({
      commandName: 'Table_SplitCellExt',
      showUI: true,
      parameter: null,
      executor: 'dc',
    })
  })

  it('maps clinical insert commands to runtime command names and options', () => {
    expect(createWriterCommandPayload('insertDateTime')).toEqual({
      commandName: 'InsertDateTimeField',
      showUI: true,
      parameter: null,
      executor: 'dc',
    })
    expect(createWriterCommandPayload('insertCheckbox')).toEqual({
      commandName: 'InsertCheckBoxOrRadio',
      showUI: true,
      parameter: { Name: 'checkbox', Type: 'checkbox', CaptionFlowLayout: true },
      executor: 'dc',
    })
    expect(createWriterCommandPayload('insertRadio')).toEqual({
      commandName: 'InsertCheckBoxOrRadio',
      showUI: true,
      parameter: { Name: 'radio', Type: 'radio', CaptionFlowLayout: true },
      executor: 'dc',
    })
    expect(createWriterCommandPayload('insertPageInfo')).toEqual({
      commandName: 'InsertPageInfoElement',
      showUI: true,
      parameter: {
        ID: 'pageinfo1',
        Height: '65',
        Width: '400',
        ValueType: 'PageIndex',
        FormatString: '第[%PageIndex%]页 共[%NumOfPages%]页',
      },
      executor: 'dc',
    })
  })

  it('finds table commands', () => {
    expect(findRibbonCommand('mergeCell')?.label).toBe('合并单元格')
  })

  it('does not duplicate command ids', () => {
    const commandIds = ribbonTabs.flatMap(tab =>
      tab.groups.flatMap(group => group.commands.map(command => command.id)),
    )

    expect(new Set(commandIds).size).toBe(commandIds.length)
  })

  it('creates payloads for every registered command', () => {
    const commandIds = ribbonTabs.flatMap(tab =>
      tab.groups.flatMap(group => group.commands.map(command => command.id)),
    )

    expect(commandIds.length).toBeGreaterThan(0)
    expect(commandIds.every(id => createWriterCommandPayload(id) !== null)).toBe(true)
  })
})
