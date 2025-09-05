using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrokkingAlgorithms
{
    using System;
    using System.Collections.Generic;

    namespace ConsoleMenus
    {
        public class MenuBuilder
        {
            private string _title = "MENU";
            private readonly List<MenuItem> _items = new();
            private bool _loop = true;
            private bool _clearOnShow = true;

            /// <summary>
            /// Represents a single menu item: can execute an Action, open a SubMenu, or Exit.
            /// </summary>
            private class MenuItem
            {
                public string Label { get; }
                public Action? Action { get; }
                public MenuBuilder? SubMenu { get; }
                public char? Hotkey { get; }
                public bool IsExit { get; }

                public MenuItem(string label, Action? action, MenuBuilder? subMenu, char? hotkey, bool isExit)
                {
                    Label = label;
                    Action = action;
                    SubMenu = subMenu;
                    Hotkey = hotkey;
                    IsExit = isExit;
                }
            }

            // ===== Fluent API =====
            public MenuBuilder Title(string title)
            {
                _title = title ?? _title;
                return this;
            }

            public MenuBuilder Loop(bool loop)
            {
                _loop = loop;
                return this;
            }

            public MenuBuilder ClearOnShow(bool clear)
            {
                _clearOnShow = clear;
                return this;
            }

            /// <summary>
            /// Add a normal menu item with an Action.
            /// </summary>
            public MenuBuilder Add(string label, Action action, char? hotkey = null)
            {
                _items.Add(new MenuItem(label, action, null, hotkey, false));
                return this;
            }

            /// <summary>
            /// Add a submenu (nested MenuBuilder).
            /// </summary>
            public MenuBuilder AddSubMenu(string label, MenuBuilder subMenu, char? hotkey = null)
            {
                _items.Add(new MenuItem(label, null, subMenu, hotkey, false));
                return this;
            }

            /// <summary>
            /// Add an Exit option.
            /// </summary>
            public MenuBuilder AddExit(string label = "Exit", char? hotkey = '0')
            {
                _items.Add(new MenuItem(label, null, null, hotkey, true));
                return this;
            }

            /// <summary>
            /// Show the menu and handle input.
            /// </summary>
            public void Show()
            {
                if (_items.Count == 0)
                    throw new InvalidOperationException("Menu is empty. Use Add(...) or AddSubMenu(...) first.");

                bool firstLoop = true;
                do
                {
                    if (_clearOnShow && !firstLoop) Console.Clear();
                    firstLoop = false;

                    Render();
                    Console.Write("Choose option: ");
                    var input = Console.ReadLine();

                    if (!TryResolveSelection(input, out var selected))
                    {
                        PrintWarn("Invalid choice.");
                        Pause();
                        continue;
                    }

                    if (selected.IsExit) break;

                    try
                    {
                        if (selected.SubMenu != null)
                        {
                            // Run the submenu
                            selected.SubMenu.Show();
                        }
                        else
                        {
                            selected.Action?.Invoke();
                        }
                    }
                    catch (Exception ex)
                    {
                        PrintError($"Error: {ex.Message}");
                    }

                    if (_loop)
                    {
                        Pause();
                    }

                } while (_loop);
            }

            // ===== Helpers =====
            private void Render()
            {
                if (_clearOnShow) Console.Clear();

                Console.WriteLine(_title);
                Console.WriteLine(new string('=', Math.Max(3, _title.Length)));

                for (int i = 0; i < _items.Count; i++)
                {
                    var item = _items[i];
                    string indexPart = $"{i + 1}.";
                    string hotkeyPart = item.Hotkey.HasValue ? $" [{char.ToUpperInvariant(item.Hotkey.Value)}]" : "";
                    Console.WriteLine($"{indexPart,-4} {item.Label}{hotkeyPart}");
                }
                Console.WriteLine();
            }

            private bool TryResolveSelection(string? input, out MenuItem selected)
            {
                selected = null!;

                // Match by hotkey (single char)
                if (!string.IsNullOrWhiteSpace(input) && input.Trim().Length == 1)
                {
                    char c = char.ToLowerInvariant(input.Trim()[0]);
                    foreach (var it in _items)
                    {
                        if (it.Hotkey.HasValue && char.ToLowerInvariant(it.Hotkey.Value) == c)
                        {
                            selected = it;
                            return true;
                        }
                    }
                }

                // Match by numeric index
                if (int.TryParse(input, out int idx))
                {
                    if (idx >= 1 && idx <= _items.Count)
                    {
                        selected = _items[idx - 1];
                        return true;
                    }
                }

                return false;
            }

            private static void Pause()
            {
                Console.WriteLine();
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
            }

            private static void PrintWarn(string msg)
            {
                var old = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(msg);
                Console.ForegroundColor = old;
            }

            private static void PrintError(string msg)
            {
                var old = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg);
                Console.ForegroundColor = old;
            }
        }
    }

}
