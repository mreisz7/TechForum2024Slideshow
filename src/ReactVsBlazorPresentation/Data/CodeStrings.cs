namespace ReactVsBlazorPresentation.Data
{
    public class CodeStrings
    {
        // Comparison: Components

        internal static string buttonJsx = """
            import React from 'react';

            function Button({ label, onClick }) {
                return (
                    <button onClick={onClick}>
                        {label}
                    </button>
                );
            }

            export default Button;
            """;

        internal static string buttonRazor = """
            <button @onclick=@OnClick>
                @Label
            </button>

            @code {
                [Parameter]
                public string Label { get; set; }

                [Parameter]
                public EventCallback OnClick { get; set; }
            }
            """;

        // Comparison: Routing

        internal static string examplePageJsx = """
            import React from 'react';

            function ExamplePage() {
              return (
                <div>
                  <h1>Example Page</h1>
                  <p>This is an example page.</p>
                </div>
              );
            }

            export default ExamplePage;
            """;

        internal static string appRoutingJsx = """
            import React from 'react';
            import { BrowserRouter as Router, 
                     Route, Link } from 'react-router-dom';
            import ExamplePage from './ExamplePage';

            function App() {
              return (
                <Router>
                   <Route path="/example" component={ExamplePage} />
                </Router>
              );
            }

            export default App;
            """;

        internal static string examplePageRazor = """
            @page "/example"

            <h1>Example Page</h1>
            <p>This is an example page.</p>
            """;

        internal static string appRoutingRazor = """
            <Router AppAssembly="@typeof(Program).Assembly">
                <Found Context="routeData">
                    <RouteView RouteData="@routeData" 
                               DefaultLayout="@typeof(MainLayout)" 
                    />
                </Found>
                <NotFound>
                    <LayoutView Layout="@typeof(MainLayout)">
                        <p>Sorry, there's nothing at this address.</p>
                    </LayoutView>
                </NotFound>
            </Router>
            """;

        // Comparison: Persistent State

        internal static string sharedStateContextJsx = """
            import React, { createContext, 
                            useState, useContext } from 'react';

            const SharedStateContext = createContext();

            export const SharedStateProvider = ({ children }) => {
                const [message, setMessage] = useState("Initial State");

                const updateMessage = (newMessage) => {
                    setMessage(newMessage);
                };

                return (
                    <SharedStateContext.Provider 
                        value={{ message, updateMessage }}>
                        {children}
                    </SharedStateContext.Provider>
                );
            };

            // Custom hook to use the shared state
            export const useSharedState = 
                () => useContext(SharedStateContext);
            """;

        internal static string comsumerComponentJsx = """
            import React from 'react';
            import { useSharedState } from './SharedStateContext';

            const ConsumerComponent = () => {
                const { message, updateMessage } = useSharedState();

                return (
                    <div>
                        <h3>Message: {message}</h3>
                        <button onClick={() => updateMessage("Updated State")}>
                            Change Message
                        </button>
                    </div>
                );
            };

            export default ConsumerComponent;
            """;

        internal static string persistentStateAppJsx = """
            import React from 'react';
            import { SharedStateProvider } from './SharedStateContext';
            import ConsumerComponent from './ConsumerComponent';

            function App() {
              return (
                <SharedStateProvider>
                  <ConsumerComponent />
                  {/* Any other components that should share the state */}
                </SharedStateProvider>
              );
            }

            export default App;
            """;

        internal static string sharedStateContextRazor = """
            <CascadingValue Value="@SharedState">
                @ChildContent
            </CascadingValue>

            @code {
                [Parameter] 
                public RenderFragment ChildContent { get; set; }
                
                public SharedState SharedState { get; set; } = new SharedState();

                public class SharedState
                {
                    public string Message { get; set; } = "Initial State";
                }
            }
            """;

        internal static string comsumerComponentRazor = """
            <h3>Message: @State.Message</h3>
            <button @onclick="UpdateMessage">Change Message</button>

            @code {
                [CascadingParameter] protected SharedStateProvider.SharedState State { get; set; }

                void UpdateMessage()
                {
                    State.Message = "Updated State";
                }
            }
            """;

        internal static string persistentStateAppRazor = """
            <SharedStateProvider>
                <ConsumerComponent />
                <!-- Any other components that should share the state -->
            </SharedStateProvider>
            """;
    }
}
